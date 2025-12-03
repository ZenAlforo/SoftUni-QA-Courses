import http from "k6/http";

import { sleep } from "k6";

export const options = {
    ext: {
    loadimpact: {
      projectID: 5950235,
    },
  },
  vus: 1,
  duration: "30s",
};

export default function () {
  http.get("https://test.k6.io");
  sleep(3);

  http.get("https://test.k6.io/contacts.php");
  sleep(2);

  http.get("https://test.k6.io/news.php");
  sleep(1);
}
