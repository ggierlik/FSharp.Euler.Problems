module ep17

//http://projecteuler.net/problem=17
//http://en.wikipedia.org/wiki/English_numerals

let to_unity number =
    match number with
    | 0 -> "zero"
    | 1 -> "one"
    | 2 -> "two"
    | 3 -> "three"
    | 4 -> "four"
    | 5 -> "five"
    | 6 -> "six"
    | 7 -> "seven"
    | 8 -> "eight"
    | 9 -> "nine"
    | _ -> failwithf "invalid unity value %d" number

let to_teens number =
    match number with
    | 10 -> "ten"
    | 11 -> "eleven"
    | 12 -> "twelve"
    | 13 -> "thirteen"
    | 14 -> "fourteen"
    | 15 -> "fifteen"
    | 16 -> "sixteen"
    | 17 -> "seventeen"
    | 18 -> "eighteen"
    | 19 -> "nineteen"
    | _ -> failwithf "invalid teens value %d" number

let to_tens number =
    let to_name n = 
        match n with
        | 1 -> "ten"
        | 2 -> "twenty"
        | 3 -> "thirty"
        | 4 -> "forty"
        | 5 -> "fifty"
        | 6 -> "sixty"
        | 7 -> "seventy"
        | 8 -> "eighty"
        | 9 -> "ninety"
        | _ -> failwithf "invalid tens value %d" number

    match (number / 10 % 10, number % 10) with
        | (0, unity) -> to_unity unity
        | (1, _) -> to_teens number
        | (tens, 0) -> to_name tens
        | (tens, unity) -> to_name tens + "-" + to_unity unity

let to_hunders number =
    let to_name n = 
        to_unity n + " hundred"

    match (number / 100, number % 100) with
    | (0, tens) -> to_tens tens
    | (hunds, 0) -> to_name hunds
    | (hunds, tens) -> to_name hunds + " and " + to_tens tens

let to_text number =
    if number = 1000 then "one thousand"
    else to_hunders number

let count_letters (s : string) =
//    s |> Seq.filter (fun c -> System.Char.IsWhiteSpace(c) |> not) 
    s |> Seq.filter (fun c -> System.Char.IsLetter(c)) |> Seq.length

let solve n = 
    let numbers = [1..n]

    numbers 
        |> List.map (fun n -> to_text n) 
        |> List.map (fun s -> count_letters s)
        |> List.reduce (+)
