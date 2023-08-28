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
          ? "border border-primary text-primary"
          : "border-none bg-gray-100"
      }`}
    >
      {tag}
    </div>
  );

export default Chip
