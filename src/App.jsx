import { useState, useEffect, useMemo } from 'react'

import { useSearchParams } from "react-router-dom";

function App() {
    const [data, setData] = useState(null);
    const [searchParams] = useSearchParams();

    useEffect(() => {
      const profile = searchParams.get('profile');

      let url = `/api/GitHubProfileData`;

      if (profile !== null) {
        url = `${url}?profile=${profile}`
      }

      (async function () {
        const res = await( await fetch(url)).json();
        console.log(res.result.result.value)
        setData(res.result.result.value);
      })();
    }, []);

    const content = useMemo(() => {
      if (data === null) {
        return <></>;
      }

      if (data.hasProfile) {
        return (
            <div className="py-4 flex justify-center">
              <div className="w-full max-w-sm bg-gray-800 rounded-lg
                          border border-gray-200 shadow-md">
                  <div className="flex flex-col items-center pt-4 pb-10">
                      <img className="mb-3 w-24 h-24 rounded-full shadow-lg"
                           src={data.userProfileData.avatarUrl}
                           alt="User Avatar Url" />
                      <h5 className="mb-1 text-xl font-medium
                                 text-gray-900 dark:text-white">
                          {data.userProfileData.name}
                      </h5>
                      <span className="text-sm text-gray-500 dark:text-gray-400">
                          {data.userProfileData.bio}
                      </span>
                      <div className="flex mt-4 space-x-3 md:mt-6">
                          <a href={data.userProfileData.url}
                             className="inline-flex items-center py-2 px-4
                                    text-sm font-medium text-center
                                    text-white bg-green-600 rounded-lg
                                    hover:bg-green-700 focus:ring-4
                                    focus:outline-none focus:ring-blue-300">
                              GitHub
                          </a>
                      </div>
                  </div>
              </div>
          </div>
        )
      } else {
        return (
          <div className="py-4 flex justify-center">
              <div className="w-full max-w-sm bg-gray-800 rounded-lg
                          border border-gray-200 shadow-md">
                  <div className="text-center p-4">
                      <h5 className="mb-1 text-xl font-medium
                                 text-gray-900 dark:text-white">
                          {data.message}
                      </h5>
                  </div>
              </div>
          </div>
        )
      }
    }, [data])

  return (
    <>
      {data === null &&
        <div className="py-4 flex justify-center">
          <div className="w-full max-w-sm bg-gray-800 rounded-lg
                    border border-gray-200 shadow-md">
            <div className="p-4 text-center">
              <h5 className="mb-1 text-xl font-medium
                           text-gray-900 dark:text-white">
                  Loading...
              </h5>
            </div>
          </div>
        </div>
      }
      {data !== null && content}
    </>
  )
}

export default App
