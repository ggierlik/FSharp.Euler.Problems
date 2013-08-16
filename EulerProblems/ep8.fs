﻿module ep8
//http://projecteuler.net/problem=8

open System

let s = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450"

let digits = [for c in s -> (int c) - (int '0')] //|> List.toSeq

let find_max_product xs =
    let rec product xs xs5 =
//        printfn "xs:  %A" (xs |> Seq.truncate 10)
//        printfn "xs5: %A" xs5

        if List.length xs5 = 5 then
            let p = List.reduce (*) xs5
            if List.length xs = 0 then
                p
            else
                let h = List.head xs
                let p1 = product xs.Tail (xs5.Tail @ [h])
                if p > p1 then
                    p
                else
                    p1
        else
            if List.length xs = 0 then
                0
            else
                let h = List.head xs
                product xs.Tail (xs5 @ [h])
        
    
    product xs [1]

let solve = 
    let result = digits |> find_max_product
//    printfn "Max product: %d" result
    result

