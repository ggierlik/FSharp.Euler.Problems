module ep4
//http://projecteuler.net/problem=4
open System

let rev (x : string) = new String(Array.rev (x.ToCharArray()))
let makeMirror n = n |> string |> rev |> int

//http://diditwith.net/blog/CategoryView,category,Project+Euler.aspx#a364f5a74-7761-4815-a8a5-1a3ab9cba3c3
let reverse n =
    let rec loop x res =
        printfn "%d %d" x res
        if x = 0 then res
        else loop (x/10) (res*10+(x%10))
    loop n 0

let isPalindrome n = 
   n = reverse n

//let s = rev "123"
//let sr = makeMirror 123
//
//printfn "%s %i" s sr

let numbers = [999 .. -1 .. 100] @ [1]

let makePalindrome n = n * 1000 + makeMirror n

printfn "palindrome %i %i" 345 (makePalindrome 345)

let isDivisible n d =
    match n % d with
        | 0 ->  let x = n / d
//                printfn "isDivisible: %i %i %i %i" n d (x / 1000) (x / 100)
                n % d = 0 && x / 1000 = 0 && x / 100 > 0
        | _ -> false

let isGreatestPalindrome n =
    let p = makePalindrome n
    
    let r =
        try
            List.find (isDivisible p) numbers
        with
            | ex -> 1

//    printfn "isGreatestPalindrome: %i %i" p r

    r <> 1

let result = List.find (isGreatestPalindrome) numbers

printfn "%i" (makePalindrome result)

ignore (Console.ReadKey(true))
