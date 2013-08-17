module ep13

open System
open System.IO
open System.Numerics

let readLines (filePath : string) = 
    let reader = File.OpenText(filePath)
    Seq.unfold(fun line ->
        if line = null then 
            reader.Close()
            None
        else
            Some(BigInteger.Parse(line), reader.ReadLine())) (reader.ReadLine())

let solve =
    readLines("ep13.in")
        |> Seq.reduce (+)
        |> fun n -> n.ToString().Substring(0, 10)
