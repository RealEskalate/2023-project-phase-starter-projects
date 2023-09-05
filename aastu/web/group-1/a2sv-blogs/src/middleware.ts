import { NextResponse } from "next/server";
import { NextRequest } from "next/server";

export function middleware(request: NextRequest) {
  console.log(request.cookies.get("token"));
  if (
    request.cookies.get("token") &&
    request.cookies.get("token")?.value !== ""
  ) {
    return NextResponse.next();
  }
  return NextResponse.redirect(new URL("/auth/login", request.url));
}

export const config = {
  matcher: ["/blogs/create", "/profile/:path*"],
};
