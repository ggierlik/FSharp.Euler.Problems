module ep25
//http://projecteuler.net/problem=25

open Fib

let solve n = 
    let fibX = Fib.fibSeqI |> Seq.map(fun i -> (i, i.ToString().Length))

    let result = fibX |> Seq.takeWhile (fun (_, l) -> l < n) |> Seq.length |> (+) 1

//    printfn "%A" result

    result