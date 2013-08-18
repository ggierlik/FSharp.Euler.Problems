module Fib

open System.Numerics
open System.Collections.Generic 

(*
let memoize f =
    let cache = Dictionary<_, _>()
    
    fun x ->
        if cache.ContainsKey(x) then cache.[x]
        else 
            let res = f x
            cache.[x] <- res
            res
*)

//based on Chapter 7 of Programming F#
let memoize (f : 'a -> 'b) =
    let cache = new Dictionary<_, _>()

    let memoizedFunc (input : 'a) =
        if cache.ContainsKey(input) then 
            printfn "cache %A" cache.[input]
            cache.[input]
        else
            let res = f input
            printfn "calc for %A: %A" input res
            cache.Add(input, res)
            res
    
    memoizedFunc 
        
#nowarn "40"

let rec memFib =
    let _fib x =
        match x with
        | 0 -> 0UL
        | 1 -> 1UL
        | 2 -> 1UL
        | x -> memFib (x-1) + memFib (x-2)
        
    memoize _fib 

let fib = memFib
