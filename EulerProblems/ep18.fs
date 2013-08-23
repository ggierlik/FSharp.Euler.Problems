module ep18
//http://projecteuler.net/problem=18

open System
open System.IO

//copied from ep11.fs
let readLines (filePath : string) = 
    let reader = File.OpenText(filePath)
    Seq.unfold(fun line ->
        if String.IsNullOrWhiteSpace(line) then 
            reader.Close()
            None
        else
            Some(line, reader.ReadLine())) (reader.ReadLine())

let readToArray filePath =
    readLines(filePath) 
        |> Seq.map(fun line -> 
            line.Split([|' '|], StringSplitOptions.None)
                |> Array.map(fun x -> (int x, 0)))
        |> Seq.toArray

let solve =
    let g = readToArray @"c:\Users\gg\Documents\Visual Studio 2010\Projects\FSharp.Euler.Problems\EulerProblems\ep18.in"
    //let g = readToArray @"ep18.in"
//    printfn "X: %d %A" g.Length g
    
    g.[0].[0] <- (fst g.[0].[0], fst g.[0].[0])

    for y in 0..g.Length-2 do
        let mutable currRow = g.[y]
        let mutable nextRow = g.[y+1]
//        printfn "currRow: %A" currRow
//        printfn "nextRow: %A" nextRow
        for x in 0..currRow.Length-1 do
            if snd currRow.[x] + fst nextRow.[x] > snd nextRow.[x] then
                nextRow.[x] <- (fst nextRow.[x], snd currRow.[x] + fst nextRow.[x])

            if snd currRow.[x] + fst nextRow.[x+1] > snd nextRow.[x+1] then
                nextRow.[x+1] <- (fst nextRow.[x+1], snd currRow.[x] + fst nextRow.[x+1])
    
    let lastRow = g.[g.Length-1]
//    printfn "lastRow: %A" lastRow
//
//    printfn "%A" g

    lastRow |> Array.maxBy (fun (x, v) -> v) |> snd
        