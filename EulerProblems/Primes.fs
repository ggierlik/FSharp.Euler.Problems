module Primes

let is_prime n =
    if n = 1UL then
        false
    elif n = 2UL then
        true
    elif n % 2UL = 0UL then
        false
    else
        let rec check n d q =
            if d > q then
                true
            else
                match n % d with
                | 0UL -> false
                | _ -> check n (d+2UL) q

        //let q = int (ceil (sqrt (float n)))
        let q = float n |> sqrt |> ceil |> uint64

        check n 3UL q

let rec get_next_prime n =
    //printfn "%d" n
    match is_prime n with
    | true -> n
    | false -> get_next_prime (n+2UL)

let primes = Seq.unfold (fun i -> 
    let p = get_next_prime i
    if p = 2UL then Some (p, p+1UL)
    else Some (p, p+2UL)) 2UL

//returns factors of n
let get_factors n =

    let rec factors n i =
        if n = 1UL then
            [1UL]
        elif is_prime n then
            [n]
        else
            let d = primes |> Seq.nth i
            //printfn "%d %d" n d

            match n % d with
            | 0UL -> d :: (factors (n/d) i)
            | _ -> factors n (i+1)

    factors n 0 |> List.sort


