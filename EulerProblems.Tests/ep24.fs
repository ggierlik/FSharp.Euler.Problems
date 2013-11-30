module ep24

open ep24
open NUnit.Framework
open FsUnit

[<Test>]
let ``Test Lists`` () =
    [0; 1; 2] |> should equal [0; 1; 2];
    [0; 1; 2] |> should not' (be equal [0; 1]);
    [] |> should equal [];
    (1, [1; 2; 3]) |> should equal (1, [1; 2; 3])
    (1, []) |> should equal (1, [])
    (1, [], [1; 2; 3]) |> should equal (1, [], [1; 2; 3])
    (0, [], [3; 2; 1]) |> should equal (0, [], [3; 2; 1])

[<Test>]
let ``Test get_longest_tail`` () =
    get_longest_tail [0..3] |> should equal (2, [0; 1], [3])
    get_longest_tail [0; 1; 3; 2] |> should equal (1, [0], [3; 2])
    get_longest_tail [0; 3; 2; 1] |> should equal (0, ([]: int list), [3; 2; 1])
    get_longest_tail [2; 3; 1; 0] |> should equal (2, ([]: list<int>), [3; 1; 0])
    get_longest_tail [4; 5; 2; 3; 1; 0] |> should equal (2, [4; 5], [3; 1; 0])

[<Test>]
let ``Test get_first_greater`` () =
    get_first_greater [0; 1; 2; 3] 2 |> should equal 3
    get_first_greater [0; 1; 2; 3] 0 |> should equal 1
    get_first_greater [3; 1; 0] 2 |> should equal 3
    (fun () -> get_first_greater [0; 1; 2; 3] 3 |> ignore) |> should throw typeof<System.ArgumentException>
