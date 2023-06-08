import React from "react";

const MainFooter = () => {
  return (
    <section class="py-24 bg-gray-100 overflow-hidden">
      <div class="container px-4 mx-auto">
        <div
          class="mb-14 p-11 rounded-2xl"
          style={{
            background: `url(
              "https://images.pexels.com/photos/3752194/pexels-photo-3752194.jpeg?auto=compress&cs=tinysrgb&w=600"
            )`,
            backgroundRepeat: "no-repeat",
            backgroundSize: "cover",
            height: "auto",
          }}
        >
          <div class="flex flex-wrap items-center -m-8">
            <div class="w-full md:w-1/2 p-8">
              <h2 class="font-heading text-6xl text-dark tracking-tighter">
                Grow your business fast with Basko Productivity Tool.
              </h2>
            </div>
            <div class="w-full md:w-1/2 p-8">
              <div class="flex flex-wrap md:justify-end">
                <div class="auto">
                  <a
                    class="inline-block px-5 py-4 text-white font-semibold tracking-tight bg-black hover:bg-gray-800 rounded-lg focus:ring-4 focus:ring-indigo-300 transition duration-200"
                    href="#"
                  >
                    Try 14 Days Free Trial
                  </a>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="flex flex-wrap justify-between -m-8">
          <div class="w-auto p-8">
            <h3 class="mb-7 text-dark font-semibold tracking-tight">
              Company
            </h3>
            <ul>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  About
                </a>
              </li>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Features
                </a>
              </li>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Works
                </a>
              </li>
              <li class=" tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Career
                </a>
              </li>
            </ul>
          </div>
          <div class="w-auto p-8">
            <h3 class="mb-7 text-dark font-semibold tracking-tight">Help</h3>
            <ul>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Customer Support
                </a>
              </li>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Delivery Details
                </a>
              </li>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Terms &amp; Conditions
                </a>
              </li>
              <li class=" tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Privacy Policy
                </a>
              </li>
            </ul>
          </div>
          <div class="w-auto p-8">
            <h3 class="mb-7 text-dark font-semibold tracking-tight">
              Resources
            </h3>
            <ul>
              <li class="mb-6 tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Free eBooks
                </a>
              </li>
              <li class="mb-6 0 tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Development Tutorial
                </a>
              </li>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  How to - Blog
                </a>
              </li>
              <li class=" tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Youtube Playlist
                </a>
              </li>
            </ul>
          </div>
          <div class="w-auto p-8">
            <h3 class="mb-7 text-dark font-semibold tracking-tight">Links</h3>
            <ul>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Free eBooks
                </a>
              </li>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Development Tutorial
                </a>
              </li>
              <li class="mb-6  tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  How to - Blog
                </a>
              </li>
              <li class=" tracking-tight">
                <a
                  class="text-dark hover:text-green-400 tracking-tight transition duration-200"
                  href="#"
                >
                  Youtube Playlist
                </a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </section>
  );
};

export default MainFooter;
