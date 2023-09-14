module CLI

open FsHttp

let testGet (url: string) =
    http {
        GET url
    }
    |> Request.send
    |> Response.toJson
    //|> fun json -> printf $"{json.ToString}"

[<EntryPoint>]
let main args =
    let url: string = "http://localhost:8080/messages"
    
    printfn $"{testGet url}"
    // Return 0
    0
