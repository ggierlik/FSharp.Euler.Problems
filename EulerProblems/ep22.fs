module ep22
//http://projecteuler.net/problem=22

open System
open System.IO

let countIndex (i, s : string) =
    s 
    |> fun s -> s.ToCharArray()
    |> Array.map (fun ch -> int ch - int 'A' + 1)
    |> Array.sum
    |> (*) <| (i+1)

let readNames (filePath : string) = 
    let reader = File.OpenText(filePath)

    let line = reader.ReadLine() 
    reader.Close()

    let names = line.Replace(@"""", "").ToUpper().Split([|','|], StringSplitOptions.RemoveEmptyEntries)
    
    names 
    |> Array.toList 
    |> List.sort
    |> List.mapi (fun i s -> (i, s, countIndex(i, s)))
    
let solve () =
    let names = readNames @"names.txt"
    names |> List.sumBy (fun (i, s, idx) -> idx)
