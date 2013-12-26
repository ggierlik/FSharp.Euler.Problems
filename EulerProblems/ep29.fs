module ep29

open System.Numerics

//http://projecteuler.net/problem=29

let powers_of a b =
    let numbers = seq {
        for i in 2I..a do
            for j in 2..b do
                yield pown i j
    }
    numbers

let len_of_dist_seq a b =
    let xs = powers_of a b
//    printfn "%A" xs

    xs
    |> Seq.distinct 
    |> Seq.length

let solve =
    len_of_dist_seq 100I 100

