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
    g |> printfn "%A"
//    grid |> printfn "%A"

    for x in [0..19] do
        printf "%2d:" x
        for y in [0..19] do
            printf "%3d" g.[x].[y]
        printfn ""
