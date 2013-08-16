module ep7_10
(*
Euler problem 7 and 10
http://projecteuler.net/problem=7
http://projecteuler.net/problem=10
*)
open Primes
open System

//printfn "%A" (Seq.take 10 primes)

//Euler problem 7th
let solve_ep7 =
//    let q = Seq.take 10001 primes |> Seq.toList |> List.rev |> List.head
//    let q = Seq.take 10001 primes |> Seq.max
    let q = primes |> Seq.skip 10000 |> Seq.head
//    printfn "10 001st prime is %d" q
    q

//Euler problem 10th
let solve_ep10 =
//    let k = primes |> Seq.take 200000 |> Seq.toList |> List.filter (fun i -> i < 2000000UL) |> List.reduce (+)
    let k = primes |> Seq.takeWhile (fun i -> i < 2000000UL) |> Seq.toList |> List.reduce (+) 
//    printfn "Sum of all primes below 2 000 000 is %d" k
    k
