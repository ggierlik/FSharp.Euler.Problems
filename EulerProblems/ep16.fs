module ep16
//http://projecteuler.net/problem=16

open System.Numerics

let powersOf2 = Seq.unfold(fun i -> Some(2I**i, i+1)) (0)

let solve n = 
    powersOf2 
        |> Seq.nth n 
        |> (fun x -> x.ToString())
        |>Seq.map(fun c -> int c - int '0') //because String is sequence of chars
        |> Seq.sum
