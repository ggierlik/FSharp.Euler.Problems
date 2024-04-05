module ep12
//http://projecteuler.net/problem=12

open System.Numerics
open Primes

let triangleNumber n =
    let r = n * (n+1UL)/2UL
//    printfn "triangleNumber %6d = %d" n r
    r

(*
let countDivisors n =
//    printfn "cd %d" n
    let rec count n c =
        if c = 0UL then 0UL
        elif n % c = 0UL then 1UL + (count n (c-1UL))
        else count n (c-1UL)

    let r = count n n
    //printfn "countDivisors: %d %d" n r
    r
*)

let countDivisors1 n = 
    let rec count n d =
//        printfn "%d %d" n d
        if n = 1UL then []
        elif is_prime n then
            [n]
        else
            let p = primes |> Seq.item d |> uint64
            if n % p = 0UL then p :: (count (n/p) d)
            else (count n (d+1))

    let divisors = count n 0
    //printfn "%A" divisors

    divisors 
        |> Seq.groupBy (fun i -> i) 
        |> Seq.toList
        |> List.map (fun (_, s) -> 1 + Seq.length s)
        //|> List.reduce (*) -- fails for empty list
        |> List.fold (fun acc elem -> acc*elem) (1)
     
(*
let triangleNumbersX = Seq.unfold (fun i -> Some (pown 2UL i, (i+1))) (2)

let triangleNumbersY = Seq.unfold (fun i -> Some (i, (i+1UL))) (2UL)
let ts0 = triangleNumbersY|>Seq.take 100 |> Seq.toList 
let ts1 = ts0 |> List.map (fun i -> (i, countDivisors1 i, countDivisors1 (i+1UL)))
let ts2 = ts1 |> List.map (fun (i, a, b) -> (i, (a-1)*b))
let ts3 = ts2 |> List.filter (fun (i, p) -> p > 5)
let ts4 = ts3 |> List.map (fun (i, p) -> (triangleNumber i, p)) |> List.sortBy (fun (n, p) -> n)
*)

(*
let triangleNumbers = Seq.unfold (fun i -> Some (triangleNumber (pown 2UL i), (i+1))) (22)

let triangleNumbers1 = Seq.unfold (fun i -> 
    let tn = triangleNumbers |> Seq.nth i
    let d = countDivisors tn
    Some ((tn, d), (i+1))) (0)

ts.Stop()

printfn "%A" (triangleNumbers1 |> Seq.take 10 |> Seq.toList)

printfn "Seq 0 time %f" ts.Elapsed.TotalMilliseconds
*)

(*
let triangleNumbersX = Seq.unfold (fun i -> Some ((i, i+1UL, triangleNumber i), (i+1UL))) (2UL)
let tz = 
    triangleNumbersX
    |> Seq.take 25
    |> Seq.map (fun (i, i1, n) -> (i, i1, n, countDivisors1 i, countDivisors1 i1, countDivisors1 n))
    |> Seq.map (fun (i, i1, n, di, di1, dn) -> (i, i1, n, di, di1, dn, di*di1))
    |> Seq.map (fun (i, i1, n, di, di1, dn, dii) -> (i, i1, n, di, di1, dn, dii, float dii / (float dn)))
*)

(*
let triangleNumbers = Seq.unfold (fun i -> Some ((i, triangleNumber i), (i+1UL))) (2UL)
let tn = 
    triangleNumbers 
    |> Seq.skip 5000
    |> Seq.take 12000 
    |> Seq.map (fun (i, n) -> (i, n, countDivisors1 n)) 
    |> Seq.filter (fun (i, n, d) -> d > 500) 
    |> Seq.sortBy (fun (i, n, d) -> n)
    |> Seq.toList

printfn "%A" (tn |> Seq.head)

printfn "Time %fs" ts.Elapsed.TotalSeconds
*)

(*
(12375UL, 76576500UL, 576)
Time 141.720075s
*)

let solve =
    let tn1 = Seq.unfold (fun i -> Some ((i, triangleNumber i), (i+1UL))) (2UL)
    let tn2 = tn1 |> Seq.map (fun (i, n) -> (i, n, countDivisors1 n)) 
    let tn3 = tn2 |> Seq.filter (fun (i, n, d) -> d > 500) 
    let tn5 = tn3 |> Seq.take 1 |> Seq.toList
//    printfn "%A" tn5
    let (_, r, _) = tn5.Head

    r
