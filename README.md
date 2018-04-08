# MusicallyRE

MusicallyRE is an educational project to learn more about Reverse Engineering. The main goal of this project is to create a functional client library which can be used to receive data from [musical.ly](https://www.musical.ly/en-US/).

> **Why musically?**  
> Simple, it has not really been done yet (publicly). A simple search only gives [mangledbottles/Musically-API](https://github.com/mangledbottles/Musically-API) which seems to be broken for a long time because of the `X-Request-Sign5` header.

## Projects

This repository consists of two projects.

### src-musically [Click](https://github.com/AeonLucid/MusicallyRE/tree/master/src-musically)

This contains C# code (netstandard 2.0) to communicate with the musical.ly rest API. Check the example to figure out how to use it.

#### Features

Some noticeable features included in this library.

- All important musical.ly headers are added.
- Random device identifier generation.
- Cache per signed in user (Caches your auth token and device identifier).
- Endpoints that are implemented;
  - Login
  - User
    - Get
    - Search
  - Discover
    - User
      - Me
      - Friends (Of the signed in user)
    - Musical
        - Owned (Retrieve musicals by userId)
        - Liked (Retrieve musicals liked by userId)
  - Musicals
    - Explore (The musicals you see when you open the app)
    - Like
      - Delete like
  - Operations
    - Follow
      - Delete follow

### src-frida [Click](https://github.com/AeonLucid/MusicallyRE/tree/master/src-frida)

This contains python code to run a Rest API that communicates with a rooted android phone in order to retrieve a valid `X-Request-Sign5` signature. This is the first time ever that I used [frida](https://www.frida.re/) and I learned a lot from it.

> At the moment of publishing this repository, I figured out (thanks to @charlieAndroidDev) that the `X-Request-Sign5` header is a `HMAC-SHA1` hash. You can read more about that [here](https://android.jlelse.eu/reverse-engineering-musical-y-live-ly-android-apps-part-1-a910daad2ec2).  
>  
> This has now been implemented into the C# library, therefor `src-frida` is no longer necessary.
