module ep6
////http://projecteuler.net/problem=6

open System

let numbers = [1..100]
let sum = List.reduce (+) numbers
let sum2 = sum * sum

let squares = List.map (fun n -> n * n) numbers
let squares2 = List.reduce (+) squares

let r = sum2 - squares2
 
printfn "%d %d %d" sum2 squares2 r
(Console.ReadKey()) |> ignore
