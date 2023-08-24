import React from "react";

export default function PaginationLinks() {
  return (
    <div className=" flex justify-center">
      <ul className="flex gap-5">
        <li className="px-2.5 rounded-md font-mono text-[#FFF] bg-[#264FAD]">
          1
        </li>
        <li className="px-2.5 rounded-md font-mono text-[#212934] bg-[#d9dee0]">
          2
        </li>
        <li className="px-2.5 rounded-md font-mono text-[#212934] bg-[#d9dee0]">
          3
        </li>
        <li className="px-2.5  rounded-md font-mono text-[#212934] bg-[#d9dee0]">
          4
        </li>
        <li className="px-2.5 rounded-md font-mono text-[#212934] bg-[#d9dee0]">
          5
        </li>
      </ul>
    </div>
  );
}
