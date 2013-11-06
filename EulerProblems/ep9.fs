module ep9
//http://projecteuler.net/problem=9    

open System

(*
max triplet is about (332, 333, 335)
*)
let aas = [1..333]

let triples = [for a in aas do 
                for b in [a+1 .. 500] do 
                    yield (a, b , 1000 - a - b)]

//printfn "%d" (List.length triples)

//let valid_triples = triples |> List.filter (fun (a, b, c) -> a < b && b < c && a + b + c = 1000)

let solve = 
    let pairs = triples |> List.map (fun (a, b, c) -> (a*a + b*b - c*c, a+b+c))

    let triples3 = triples |> List.filter (fun (a, b, c) -> a*a + b*b = c*c && a + b + c = 1000)

    let (a, b, c) = triples3.Head

    let result = a * b * c

//    printfn "result %d" result
    result



