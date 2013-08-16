module ep14
//http://projecteuler.net/problem=14

open System

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
    let rec calc i acc =
        match i with
        | 1L -> 1+acc
        | i when i%2L = 0L -> calc (i/2L) (acc+1)
        | i when i%2L = 1L -> calc (3L*i+1L) (acc+1)
        | _ -> failwith (sprintf "Wrong value %d" i)
    calc (int64 n) 0

//printfn "collatzSeqLen %f" t1.Elapsed.TotalMilliseconds

//printfn "collatzSeq %f" t2.Elapsed.TotalMilliseconds

let chooseMax acc elem =
    let (a, b) = acc
    let (x, y) = elem

    if b > y then acc
    else elem

let ns = [999999..-1..1]

let solve1 = 
    let ns1 = [for i in ns do yield (i, collatzSeqLength i)]

    let rn = ns1 |> List.reduce chooseMax

//    printfn "%A" rn
    let (r, _) = rn
    r

let solve2 = 
    let ns1 = [for i in ns do yield (i, (collatzSeq (int64 i)) |> Seq.length)]
    let rn = ns1 |> List.reduce chooseMax

//    printfn "%A" rn
    let (r, _) = rn
    r
