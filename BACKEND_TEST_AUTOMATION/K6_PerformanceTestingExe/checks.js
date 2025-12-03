import http from "k6/http";
import { sleep } from "k6";
import { check } from "k6";

export default function () {
  const res = http.get("https://test.k6.io/news.php");

  check(res, {
    "is status 200": (r) => r.status === 200,
    "homepage welcome header presents": (r) => r.body.includes("In the news"),
  });
  sleep(1);
}
