module ep5
//http://projecteuler.net/problem=5

open System

// 1. factor all the numbers
// 2. Select common subset
// 3. Multiple numbers from common subject
let primes = [|2; 3; 5; 7; 11; 13; 17; 19|]

//generate factors for 1..20
let rec get_factors n i =
    if n = 1 then
        [1]
    elif i = Array.length primes then
        []
    else
        let d = primes.[i]

        match n % d with
        | 0 -> d :: (get_factors (n/d) i)
        | _ -> get_factors n (i+1)

//list of lists of factors
let factors_2 = [for i in 1 .. 20 do yield List.sort (get_factors i 0)]
printfn "factors 2: %A" factors_2

let find_elems acc list =
    printfn "acc: %A" acc
    printfn "list: %A" list

    let rec check_elem a l =
        printfn "a: %A\nl: %A" a l

        if List.isEmpty a then
            l
        elif List.isEmpty l then
            []
        else
            let n = List.head a
            let m = List.head l

            if n < m then
                check_elem a.Tail l
            elif n = m then
                check_elem a.Tail l.Tail
            else
                m :: (check_elem a.Tail l.Tail)

    let new_elems = check_elem acc list

    printfn "new: %A" new_elems
    List.sort (List.append acc new_elems)

let factors_3 = List.reduce find_elems factors_2
printfn "factors 3: %A" factors_3

let result = List.reduce (*) factors_3
printfn "result: %d" result

Console.ReadKey(true) |> ignore 
