import React from 'react'

interface ChipProps {
    tag: string;
    isSelected: boolean;
    onClick: (tag: string) => void;
  }
  
  const Chip: React.FC<ChipProps> = ({ tag, isSelected, onClick }) => (
    <div
      onClick={() => onClick(tag)}
      className={`px-3 py-1 rounded-full cursor-pointer ${
        isSelected
<<<<<<< HEAD
          ? "border border-primary text-primary"
          : "border-none bg-gray-100"
=======
          ? "border border-blue-500 text-blue-500"
          : "border-none bg-gray-300"
>>>>>>> 71ad5a6 (feat(aait.web.g3):Add create blog page)
      }`}
    >
      {tag}
    </div>
  );

export default Chip
