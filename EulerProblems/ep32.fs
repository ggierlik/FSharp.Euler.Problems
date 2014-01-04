module ep32

//http://projecteuler.net/problem=32

// n * m = p

let ns = seq {1..98}

let ms n = Seq.unfold (fun i -> Some (i, i+1)) (n)
