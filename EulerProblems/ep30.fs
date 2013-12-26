module ep30

//http://projecteuler.net/problem=30

let digits n = 
    Seq.unfold (fun n -> if (n = 0) then None else Some(n % 10, n/10)) n
    
