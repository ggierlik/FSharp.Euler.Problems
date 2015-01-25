module ep34

open ep34
open NUnit.Framework
open FsUnit

[<Test>]
let ``digits should get list of digits`` () =
    digits 145 |> Seq.toList |> should equal [5;4;1]
    digits 14 |> Seq.toList |> should equal [4;1]
    digits 144 |> Seq.toList |> should equal [4;4;1]
    
[<Test>]
let ``sum should return sum of digit factorials`` () =
    sum 145 |> should equal 145
    sum 14 |> should equal 25
    sum 41 |> should equal 25
    sum 45 |> should equal 144


