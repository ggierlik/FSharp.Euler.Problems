module ep5
//http://projecteuler.net/problem=5

open System

// 1. factor all the numbers
// 2. Select common subset
// 3. Multiple numbers from common subject
let private primes = [|2; 3; 5; 7; 11; 13; 17; 19|]

let solve = 
    //generate factors for 1..20
    let rec get_factors n i acc =
        if n = 1 then
            1 :: acc
        elif i = Array.length primes then
            acc
        else
            let d = primes.[i]

            match n % d with
            | 0 -> get_factors (n/d) i (d::acc)
            | _ -> get_factors n (i+1) acc

    //list of lists of factors
    let factors_2 = [for i in 1 .. 20 do yield List.sort (get_factors i 0 [])]
    //printfn "factors 2: %A" factors_2

    let find_elems acc list =
    //    printfn "acc: %A" acc
    //    printfn "list: %A" list

        let rec check_elem a l _acc =
    //        printfn "a: %A\nl: %A" a l

            if List.isEmpty a then
                List.append l _acc
            elif List.isEmpty l then
                _acc
            else
                let n = List.head a
                let m = List.head l

                if n < m then
                    check_elem a.Tail l _acc
                elif n = m then
                    check_elem a.Tail l.Tail _acc
                else
                    check_elem a.Tail l.Tail (m::_acc)

        let new_elems = check_elem acc list []

    //    printfn "new: %A" new_elems
        List.sort (List.append acc new_elems)

    let factors_3 = List.reduce find_elems factors_2
    //printfn "factors 3: %A" factors_3

    let result = List.reduce (*) factors_3
    //printfn "result: %d" result

    result
