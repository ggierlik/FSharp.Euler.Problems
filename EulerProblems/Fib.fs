module Fib

open System.Numerics
open System.Collections.Generic 

//based on Chapter 7 of Programming F#
let memoize (f : 'a -> 'b) =
    let cache = new Dictionary<_, _>()

    let memoizedFunc (input : 'a) =
        if cache.ContainsKey(input) then 
//            printfn "cache %A" cache.[input]
            cache.[input]
        else
            let res = f input
//            printfn "calc for %A: %A" input res
            cache.Add(input, res)
            res
    
    memoizedFunc 
        
#nowarn "40"

let rec memFibUL =
    let _fib x =
        match x with
        | 0 -> 0UL
        | 1 -> 1UL
        | 2 -> 1UL
        | x -> memFibUL (x-1) + memFibUL (x-2)
        
    memoize _fib 

let fibUL = memFibUL

let rec memFibI =
    let _fib x =
        match x with
        | 0 -> 0I
        | 1 -> 1I
        | 2 -> 1I
        | x -> memFibI (x-1) + memFibI (x-2)
        
    memoize _fib 

let fibI = memFibI

let fibSeqUL = Seq.unfold(fun i -> Some(fibUL i, i+1)) (1)
let fibSeqI = Seq.unfold(fun i -> Some(fibI i, i+1)) (1)
