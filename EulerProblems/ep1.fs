﻿module ep1
//http://projecteuler.net/problem=1

let solve =
    seq { 1 .. 999 } |> Seq.filter (fun x -> x % 3 = 0 || x % 5 = 0) |> Seq.sum

