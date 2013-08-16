module ep14
//http://projecteuler.net/problem=14

open System
open System.Diagnostics

let collatzSeq n =
    Seq.unfold (fun i ->
        if i = 1L then Some(1L, 0L)
        elif i < 0L then
            failwith (sprintf "Wrong value %d" i)
        elif i = 0L then None
        elif i % 2L = 0L then Some(i, i/2L)
        else Some(i, 3L*i+1L)
    ) (n)

let collatzSeqLength n =
    let rec calc i =
        match i with
        | 1L -> 1
        | i when i%2L = 0L -> (calc (i/2L)) + 1
        | i when i%2L = 1L -> (calc (3L*i+1L)) + 1
        | _ -> failwith (sprintf "Wrong value %d" i)
    calc (int64 n)

let ns = [999999..-1..1]

let t1 = Stopwatch.StartNew()
let ns1 = [for i in ns do yield (i, collatzSeqLength i)]
t1.Stop()

printfn "collatzSeqLen %f" t1.Elapsed.TotalMilliseconds

let t2 = Stopwatch.StartNew()
let ns2 = [for i in ns do yield (i, (collatzSeq (int64 i)) |> Seq.length)]
t2.Stop()

printfn "collatzSeq %f" t2.Elapsed.TotalMilliseconds

let chooseMax acc elem =
    let (a, b) = acc
    let (x, y) = elem

    if b > y then acc
    else elem

let r1 = ns1 |> List.reduce chooseMax
let r2 = ns2 |> List.reduce chooseMax

printfn "%A %A" r1 r2

(Console.ReadKey()) |> ignore
