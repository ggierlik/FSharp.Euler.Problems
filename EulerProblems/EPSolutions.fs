module EPSolutions

open System

//#I "c:\Documents and Settings\gg\Documents\Visual Studio 2010\Projects\FSharp.Euler.Problems\EulerProblems\";;

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

//ep11.solve |> printfn "%d"

//ep12.solve |> printfn "%d"

//ep13.solve |> printfn "%s"

//ep14.solve1 |> printfn "%d"
//printfn "Time %fms" ts.Elapsed.TotalMilliseconds
//ts.Reset()

//ep14.solve2 |> printfn "%d"
//printfn "Time %fms" ts.Elapsed.TotalMilliseconds
//ts.Reset()

//ep15.solve 20I |> printfn "%A"

//ep16.solve 1000 |> printfn "%d"

//ep17.solve 1000 |> printfn "%d"

//ep18.solve @"ep18.in" |> printfn "%d"
//ep18.solve @"ep67.in" |> printfn "%d"

//ep19.solve_1 () |> printfn "%d"

//ep20.solve 100 |> printfn "%d"

//ep21.solve () |> printfn "%d"

//ep22.solve () |> printfn "%d"

//ep23.solve () |> printfn "%d"

//ep24.solve 1000000 [0..9] |> printfn "%s"

//ep25.solve 1000 |> printfn "%A"

//ep27.solve () |> printfn "%d"

//ep28.solve 1001 |> printfn "%d"

//ep29.solve |> printfn "%d"

//ep30.solve 5 |> printfn "%d"

ep31.solve 5 |> printfn "%d"

//ep32.solve |> printfn "%d"
//------------------------------------------

printfn "Time %fs" ts.Elapsed.TotalSeconds
ts.Reset()

Console.ReadKey() |> ignore
