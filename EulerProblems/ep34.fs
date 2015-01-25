module ep34

//http://projecteuler.net/problem=34

open System

let factorial n =
    if n = 0 then 1
    else
        [1..n] |> List.reduce (*)


//we need just first 10 results
let factorials = [0..9] |> List.map(fun n -> factorial n) |> List.toArray

let digits n = 
    Seq.unfold (fun n -> if (n = 0) then None else Some(n % 10, n/10)) n

let sum n =
    digits n |> Seq.map(fun n -> factorials.[n]) |> Seq.sum

///let numbers = Seq.unfold(fun i -> Some(i, i+1)) (3)
//all numbers from 3 until 1M
//9! = 362880 -> 999 ~ 1M
//8! = 40320 -> 888888 ~ 241920
let numbers = [3..1000000]

let solve =
    numbers |> List.filter(fun n -> sum n = n) |> List.sum


