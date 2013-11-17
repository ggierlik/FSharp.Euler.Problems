module ep23

open System.Collections

//http://projecteuler.net/problem=23
//Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
//it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers

//http://en.wikipedia.org/wiki/Abundant_number
//Wiki: Every integer greater than 20161 can be written as the sum of two abundant numbers.[4]
//http://oeis.org/A048242
//http://oeis.org/A048242/b048242.txt

(*
4179871
Time 34.987537s
*)
let divisors_old n =
    seq { for i in 1..n/2 do if n % i = 0 then yield i}

(*
4110647
Time 4.002486s
*)
let divisors n =
    let bf = n |> float |> sqrt
    let bound = (bf |> ceil |> int)

    seq { for i in 1..bound do 
            if n % i = 0 then 
                yield i
                if i <> 1 && i*i <> n then yield n/i
        }
            
let d n =
    divisors n |> Seq.sum

//let numbers = [1..1000]
let numbers = [0..28123]

let abundants = 
    numbers 
//    |> List.map (fun n -> d n)
    |> List.filter (fun n -> n < d n)
//    |> List.map (fun (n, d) -> n)
//    |> List.rev
    |> List.toArray

//set to true if number is abundant
let abundants_bits = new System.Collections.BitArray (28125, false)

for n in abundants do
    abundants_bits.[n] <- true

//set to true if number is sum of abundants
let sum_of_abundants_bits = new System.Collections.BitArray (28125, false)

let check_if_sum_exists n =
    let nums = abundants |> Array.filter (fun m -> m < n)

//    printfn "%d %A" n nums

    let rec check n m =
        
        if m = nums.Length then false
        else if n-nums.[m] >= 0 && abundants_bits.[n-nums.[m]] then true
        else check n (m+1)

    let r = check n 0
//    printfn "%d %A" n r
    r

let is_sum_of_abundants n =
    if n % 2 = 0 && abundants_bits.[n/2] then true
    else check_if_sum_exists n

for i in numbers do
    sum_of_abundants_bits.[i] <- is_sum_of_abundants i

//numbers which are sum of two abundant numbers
let nums = seq { for i in numbers do if not sum_of_abundants_bits.[i] then yield i}

let solve () =
    nums |> Seq.sum

//solve () |> printfn "%d"
