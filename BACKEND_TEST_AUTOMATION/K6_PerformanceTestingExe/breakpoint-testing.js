import http from "k6/http";

import { sleep } from "k6";

// export const options = {
//   vus: 100,
//   duration: "30m",
// };

export const options = {
  stages: [{ duration: "2h", target: 200000 }],
};

export default function () {
  http.get("https://test.k6.io/news.php");
  sleep(1);
}
