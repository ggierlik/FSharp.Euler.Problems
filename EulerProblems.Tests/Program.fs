module Tests

open ep17
open NUnit.Framework
open FsUnit

[<Test>]
let ``Test to_text for unities`` () =
    to_unity(0) |> should equal "zero"
    to_unity(1) |> should equal "one"
    to_unity(2) |> should equal "two"
    to_unity(3) |> should equal "three"
    to_unity(5) |> should equal "five"
    (fun () -> to_unity(10) |> ignore) |> should throw typeof<System.Exception>

[<Test>]
let ``Test to_text for teens`` () =
    to_teens(10) |> should equal "ten"
    to_teens(11) |> should equal "eleven"
    to_teens(12) |> should equal "twelve"
    to_teens(15) |> should equal "fifteen"
    (fun () -> to_teens(1) |> ignore) |> should throw typeof<System.Exception>
    (fun () -> to_teens(25) |> ignore) |> should throw typeof<System.Exception>

[<Test>]
let ``Test to_text for tens`` () =
    to_tens(1) |> should equal "ten"
    to_tens(2) |> should equal "twenty"
    to_tens(3) |> should equal "thirty"
    to_tens(4) |> should equal "forty"
    to_tens(5) |> should equal "fifty"
    (fun () -> to_teens(100) |> ignore) |> should throw typeof<System.Exception>

[<Test>]
let ``Test to_text for hunders`` () =
    to_hunders(1) |> should equal "one hundred"
    to_hunders(3) |> should equal "three hundred"
    to_hunders(6) |> should equal "six hundred"

[<Test>]
let ``Test to_text for numbers`` () =
    to_text(1) |> should equal "one"
    to_text(7) |> should equal "seven"
    to_text(10) |> should equal "ten"
    to_text(11) |> should equal "eleven"
    to_text(12) |> should equal "twelve"
    to_text(15) |> should equal "fifteen"
    to_text(16) |> should equal "sixteen"
    to_text(20) |> should equal "twenty"
    to_text(50) |> should equal "fifty"
    to_text(44) |> should equal "forty-four"
    to_text(55) |> should equal "fifty-five"
    to_text(57) |> should equal "fifty-seven"
    to_text(99) |> should equal "ninety-nine"
    to_text(342) |> should equal "three hundred and forty-two"
    to_text(115) |> should equal "one hundred and fifteen"
    to_text(400) |> should equal "four hundred"
    to_text(603) |> should equal "six hundred and three"
    to_text(1000) |> should equal "one thousand"

