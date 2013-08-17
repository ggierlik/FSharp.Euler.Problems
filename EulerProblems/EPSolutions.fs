module EPSolutions

open System
open ep1
open ep2
open ep3
open ep4
open ep5
open ep6
open ep7_10
open ep8
open ep9
open ep11
open ep12 
open ep14

let ts = System.Diagnostics.Stopwatch.StartNew()

//ep1.solve |> printfn "%d"
//ep2.solve |> printfn "%d"
//ep3.solve |> printfn "%d"

//ep4.solve |> printfn "%d"
//ep5.solve |> printfn "%d"
//ep6.solve |> printfn "%d"

//ep7_10.solve_ep7 |> printfn "%d"
////printfn "Time %fms" ts.Elapsed.TotalMilliseconds
//ts.Reset()

//ep8.solve |> printfn "%d"
//ep9.solve |> printfn "%d"

//ep7_10.solve_ep10 |> printfn "%d"
////printfn "Time %fms" ts.Elapsed.TotalMilliseconds
//ts.Reset()

//ep12.solve |> printfn "%d"

//ep14.solve1 |> printfn "%d"
//printfn "Time %fms" ts.Elapsed.TotalMilliseconds
//ts.Reset()

//ep14.solve2 |> printfn "%d"
//printfn "Time %fms" ts.Elapsed.TotalMilliseconds
//ts.Reset()

ep11.solve |> printfn "%d"

Console.ReadKey() |> ignore
