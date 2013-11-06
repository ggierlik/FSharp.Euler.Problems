module ep15
//http://projecteuler.net/problem=15

open System.Numerics

//http://mathworld.wolfram.com/LatticePath.html
//http://www.robertdickau.com/lattices.html
//http://www.mathblog.dk/project-euler-15/
//http://blog.functionalfun.net/2008/07/project-euler-problem-15-city-grids-and.html
//http://code.jasonbhill.com/python/project-euler-problem-15/

//number of paths is Binomial_coefficient(2n, n) = (2n!/n!n!) = n!at/n!n! = at/n!
let solve n =
    let at = [n+1I..n*2I]
//    printfn "%A" at
    let a = List.reduce (fun acc elem -> acc * elem) at

    let bt = [1I..n]
//    printfn "%A" bt
    let b = List.reduce (fun acc elem -> acc * elem) bt
    
    let r = a / b
//    printfn "%A %A %A" a b r

    r
