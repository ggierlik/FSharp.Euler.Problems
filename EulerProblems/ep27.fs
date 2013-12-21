module ep27
//http://projecteuler.net/problem=27

//TODO: add memoize
let is_prime n =
    if n <= 0 then
        false
    elif n = 1 then
        false
    elif n = 2 then
        true
    elif n % 2 = 0 then
        false
    elif n = 3 then
        true
    elif n = 5 then
        true
    elif n = 7 then
        true
    elif n % 3 = 0 then
        false
    elif n % 5 = 0 then
        false
    elif n % 7 = 0 then
        false
    else
        let rec check n d q =
            if d > q then
                true
            else
                match n % d with
                | 0 -> false
                | _ -> check n (d+2) q

        let q = float n |> sqrt |> ceil |> int

        check n 3 q

let q1 n =
    n*n + n + 41

let q2 n =
    n*n - 79*n + 1601

//returns quadratic formula n^2 + an + b for given a and b
let q a b =
    let f n =
        n * n + a * n + b

    f

//gen seqence of primes given by quadratic formula f
let gen_seq f =
    Seq.unfold (fun i ->
                let p = f i
                if is_prime p then Some (p, i+1)
                else None) 0

let primes_by_f = seq {
    let max_l = ref (0)

    for a in [-999..999] do
        for b in [-999..999] do
            let f = q a b
            let s = gen_seq f
            let l = s |> Seq.length
            if l > !max_l then
//                printfn "%d %d %d %A" a b l (s |> Seq.toList)
                max_l := l
                yield (a, b, l)
}

let primes_f = 
    primes_by_f 
    |> Seq.toList 
    |> List.map (fun (a, b, l) -> (a, b, a*b, l))
    |> List.sortBy (fun (a, b, ab, l) -> -l)

let solve () =
    let (a, b, product, n) = primes_f |> List.head
    product
