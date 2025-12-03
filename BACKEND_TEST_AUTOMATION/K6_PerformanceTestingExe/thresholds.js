import http from "k6/http";
import { sleep } from "k6";
import { check } from "k6";

export const options = {
  ext: {
    loadimpact: {
      projectID: 5950235,
    },
  },
  vus: 100,
  duration: "1m",
  thresholds: {
    http_req_duration: ["p(90)<300", "p(95)<500"], // 90% of the requests must complete below 300ms, 95% of requests must complete below 500ms
    http_req_failed: ["rate<0.01"], // less than 1% of requests should fail
  },
};

export default function () {
  const res = http.get("https://test.k6.io/news.php");

  check(res, {
    "is status 200": (r) => r.status === 200,
    "homepage welcome header presents": (r) => r.body.includes("News"),
  });
  sleep(1);
}
