module ep35
//https://projecteuler.net/problem=35

let isPrime n =
    if n = 1 then
        false
    elif n = 2 then
        true
    elif n % 2 = 0 then
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

let digits number = 
    let convert num =
        Seq.unfold (fun n -> if (n = 0) then None else Some(n % 10, n/10)) num

    convert number |> Seq.toList |> List.rev

let buildNumber xs =
    xs |> List.reduce (fun acc elem -> 10*acc+elem)

//http://stackoverflow.com/a/22551722/1483
let getNumbers n =
    let number = digits n
    let length = number |> List.length
    //List.permute moves each element right about n position (modulo length of list
    (*
    > [1;2;3;4]|> List.permute(fun i -> (i+1)%4);;
val it : int list = [4; 1; 2; 3]
> [1;2;3;4]|> List.permute(fun i -> (i+3)%4);;
val it : int list = [2; 3; 4; 1]
> [1;2;3;4;5;6;7]|> List.permute(fun i -> (i+3)%7);;
val it : int list = [5; 6; 7; 1; 2; 3; 4]
    *)
    let perm n = number |> List.permute (fun index -> (index + n) % length) 
    [1 .. length] |> List.rev |> List.map perm

let isAllPrimes xs =
   xs |> List.forall (fun n -> isPrime n) 
    
let solve n =
    let numbers = [1..n]

    numbers
    |> List.filter (fun n -> isPrime n)                    //leave only primes
    |> List.map getNumbers                                  //gen all numbers (by rotating digits)
    |> List.map (fun xs -> xs |> List.map buildNumber)      //get numbers back
    |> List.map (fun xs -> (List.head xs, isAllPrimes xs))  //get list of tuples as (number, if all are primes)
    |> List.filter (fun elem -> snd elem)                   //leave only interesting ones
    |> List.length                                          //and count them

