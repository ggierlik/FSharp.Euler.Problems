module ep11

open System
open System.IO

//let grid = Array2D.create 20 20 0

let readLines (filePath : string) = 
    let reader = File.OpenText(filePath)
    Seq.unfold(fun line ->
        if line = null then 
            reader.Close()
            None
        else
            Some(line, reader.ReadLine())) (reader.ReadLine())

let readToArray filePath =
    readLines(filePath) 
        |> Seq.map(fun line -> 
            line.Split([|' '|], StringSplitOptions.None)
                |> Array.map int32)
        |> Seq.toArray

let solve =
    let g = readToArray "ep11.in"
//    g |> printfn "%A"

    let numbers x y dx dy =
        Seq.unfold(fun (x, y, dx, dy, i) ->
            if i = 4 then None
            else
                Some(g.[x+dx*i].[y+dy*i], (x, y, dx, dy, i+1))) (x, y, dx, dy, 0)
(*
    numbers 0 0 1 0 |> printfn "%A"
    numbers 0 0 0 1 |> printfn "%A"
    numbers 0 0 1 1 |> printfn "%A"
*)
(*
    for x in [0..19] do
        printf "%2d:" x
        for y in [0..19] do
            printf "%3d" g.[x].[y]
        printfn ""
*)

    let productOfNumbers x y dx dy =
        let ns = numbers x y dx dy
        let r = ns |> Seq.reduce (*)
//        printfn "%2d %2d %2d %2d %12d %A" x y dx dy r ns
        r

    let products = seq {
        for x in [0..19] do
            for y in [0..19] do
                if x <= 16 then yield productOfNumbers x y 1 0
                if y <= 16 then yield productOfNumbers x y 0 1
                if x <= 16 && y <= 16 then yield productOfNumbers x y 1 1
                if x >= 3 && y <= 16 then yield productOfNumbers x y -1 1
    }

//    products |> Seq.toList |> printfn "%A"

    products |> Seq.max
