module ep7_10
(*
Euler problem 7 and 10
http://projecteuler.net/problem=7
http://projecteuler.net/problem=10
*)
open Primes
open System

printfn "%A" (Seq.take 10 primes)

//Euler problem 7th
let q = Seq.take 10001 primes |> Seq.toList |> List.rev |> List.head;;

printfn "10 001st prime is %d" q

//Euler problem 10th
let k = Seq.take 200000 primes |> Seq.toList |> List.filter (fun i -> i < 2000000UL) |> List.reduce (+);;

printfn "Sum of all primes below 2 000 000 is %d" k

(Console.ReadKey()) |> ignore
