module ep19

//http://projecteuler.net/problem=19

let is_leap_year year =
    if year % 100 = 0 && year % 400 <> 0 then
        false
    else
        if year % 4 = 0 then
            true
        else
            false
            
let get_month_length month year =
    match month with 
    | 1 | 3 | 5 | 7 | 8 | 10 | 12 -> 31
    | 4 | 6 | 9 | 11 -> 30
    | 2 -> if is_leap_year year then 29 else 28
    | _ -> failwithf "wrong month %d" month

let get_year_length year =
    if is_leap_year year then 366 else 365

let get_years first_year last_year =
    Seq.unfold(fun i ->
        if i > last_year then None
        else Some(get_year_length i, i+1)) first_year

let get_num_of_weeks days =
    days / 7

let solve =
    let years = get_years 1900 2000
    let y1900 = get_year_length 1900
    
    let weeks_total = years |> Seq.sum |> get_num_of_weeks
    let weeks_1900  = get_num_of_weeks y1900

    weeks_total - weeks_1900

(*
TODO
 * solve correct problem :)
 * use .NET Datetime and DayOfWeek
 * try without .NET support
*)
