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
    | _ -> failwith "invalid value"

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
    | _ -> failwith "invalid value"

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
    | _ -> failwith "invalid value"

let to_hunders number =
    ""

let to_text number =
    match (number / 10, number % 10) with
    | (0, unity) -> to_unity unity
    | (1, _) -> to_teens number
    | (tens, 0) -> to_tens tens
    | (tens, unity) -> to_tens tens + "-" + to_unity unity

//    | 1 -> "one"
//    | 10 -> "ten"
//    | 11 -> "eleven"
//    | 12 -> "twelve"
//    | 15 -> "fifteen"
//    | 115 -> "one hundred and fifteen"
//    | 342 -> "three hundred and forty two"
//    | 1000 -> "one thousand"
//    | _ -> "xxx"

