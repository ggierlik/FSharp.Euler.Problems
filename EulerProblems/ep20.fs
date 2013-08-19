module ep20
//http://projecteuler.net/problem=20

open System
open System.Numerics

let factorialUL = Seq.unfold(fun (i, j) -> Some(i*j, (i*j, j+1))) (1, 1)
let factorialI = Seq.unfold(fun (i, j) -> Some(i*j, (i*j, j+1I))) (1I, 1I)

let solve n =
    let nFactorial = factorialI |> Seq.nth (n-1)
//    printfn "factorial of %d is %A %s" n nFactorial (nFactorial.ToString())

    let digits = nFactorial.ToString() |> fun s -> s.ToCharArray() |> Array.map (fun s -> int s - int '0')

//    printfn "digits %A" digits

    let result = digits |> Array.reduce (+)
    
//    printfn "sum of digits of %d! id %A" n result

    result