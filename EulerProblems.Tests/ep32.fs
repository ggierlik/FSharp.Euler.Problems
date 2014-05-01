module ep32

open ep32
open NUnit.Framework
open FsUnit

[<Test>]
let ``Test is_pandigital`` () =
    is_pandigital 82 93 |> should equal false
    is_pandigital 39 186 |> should equal true
    is_pandigital 3 4 |> should equal false
    is_pandigital 7 8 |> should equal false
    is_pandigital 7 7 |> should equal false
