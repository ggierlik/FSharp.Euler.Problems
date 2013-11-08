﻿module ep17

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
    match number with
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

let to_hunders number =
    to_unity number + " hundred"

let to_text number =
    if number = 1000 then "one thousand"
    else
        match (number / 100, number / 10 % 10, number % 10) with
        | (0, 0, unity) -> to_unity unity
        | (0, 1, _) -> to_teens number
        | (0, tens, 0) -> to_tens tens
        | (0, tens, unity) -> to_tens tens + "-" + to_unity unity
        | (hunds, 0, 0) -> to_hunders hunds
        | (hunds, 0, unity) -> to_hunders hunds + " and " + to_unity unity
        | (hunds, 1, _) -> to_hunders hunds + " and " + to_teens (number % 100)
        | (hunds, tens, 0) -> to_hunders hunds + " and " + to_tens tens
        | (hunds, tens, unity) -> to_hunders hunds + " and " + to_tens tens + "-" + to_unity unity
