import http from "k6/http";

import { sleep } from "k6";

// export const options = {
//   vus: 100,
//   duration: "30m",
// };

export const options = {
    ext: {
    loadimpact: {
      projectID: 5950235,
    },
  },
  stages: [
    { duration: "15s", target: 10 },
    { duration: "1m", target: 10 },
    { duration: "15s", target: 0 },
  ]
};

export default function () {
  http.get("https://test.k6.io");
  sleep(3);

  http.get("https://test.k6.io/contacts.php");
  sleep(2);

  http.get("https://test.k6.io/news.php");
  sleep(1);
}
