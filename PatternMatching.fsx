open System

/// You can also use the shorthand function construct for pattern matching, 
/// which is useful when you're writing functions which make use of Partial Application.
let private parseHelper ( f:(String -> _ * _) ) = f >> function
    | (true, item) -> Some item
    | (false, _) -> None

let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

let result = parseDateTimeOffset "1970-01-01"
match result with
| Some dto -> printfn "It parsed!"
| None -> printfn "It didn't parse!"

// Define some more functions which parse with the helper function.
let parseInt = parseHelper Int32.TryParse
let parseDouble = parseHelper Double.TryParse
let parseTimeSpan = parseHelper TimeSpan.TryParse

printfn "%d" <|
    match parseInt "42" with
    | Some x -> x
    | None -> 0

printfn "%d" <|
    match parseHelper Int32.TryParse "420" with
    | Some x -> x
    | None -> 0

let product : int -> int -> int
    = fun x y -> x * y
let product2 : int -> int -> int
    = ( * )

printfn "product: %d" <| product 2 3

printfn "Some: %A" <| parseInt "123"