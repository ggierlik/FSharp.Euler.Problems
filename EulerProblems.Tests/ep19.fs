module ep19

open ep19
open NUnit.Framework
open FsUnit

[<Test>]
let ``Test is_leap_year`` () =
    is_leap_year(1900) |> should equal false
    is_leap_year(2000) |> should equal true
    is_leap_year(1996) |> should equal true
    is_leap_year(1995) |> should equal false
    is_leap_year(1990) |> should equal false
    is_leap_year(1988) |> should equal true

[<Test>]
let ``Test get_months_length`` () =
    get_month_length 1 1900 |> should equal 31
    get_month_length 2 1900 |> should equal 28
    get_month_length 3 1900 |> should equal 31
    get_month_length 4 1900 |> should equal 30
    get_month_length 12 1900 |> should equal 31
    get_month_length 2 1902 |> should equal 28
    get_month_length 2 1904 |> should equal 29
    get_month_length 2 1988 |> should equal 29
    get_month_length 2 1989 |> should equal 28
    (fun () -> get_month_length 13 1989 |> ignore) |> should throw typeof<System.Exception>

[<Test>]
let ``Test get_year_length`` () =
    get_year_length 1900 |> should equal 365
    get_year_length 1902 |> should equal 365
    get_year_length 1904 |> should equal 366
    get_year_length 1989 |> should equal 365
    get_year_length 1988 |> should equal 366
    get_year_length 2000 |> should equal 366

[<Test>]
let ``Test get_num_of_weeks`` () =
    get_num_of_weeks 7 |> should equal 1
    get_num_of_weeks 10 |> should equal 1
    get_num_of_weeks 14 |> should equal 2
    get_num_of_weeks 13 |> should equal 1
    get_num_of_weeks 15 |> should equal 2
    get_num_of_weeks 21 |> should equal 3