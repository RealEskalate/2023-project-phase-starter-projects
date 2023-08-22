import 'package:flutter/material.dart';

class FilterTagChip extends StatelessWidget {
  final String name;
  final bool selected;
  const FilterTagChip({
    super.key,
    required this.name,
    required this.selected,
    });

  @override
  Widget build(BuildContext context) {
    return Flexible(
      child: FilterChip(
                selected: selected,
                padding: const EdgeInsets.symmetric(horizontal: 15, vertical: 1),
                showCheckmark: false,
                selectedColor: Theme.of(context).colorScheme.primary,
                onSelected: (bool value) {},
                labelStyle: TextStyle(
                  color: Theme.of(context).colorScheme.primary,
                ),
                side: BorderSide(
                    
                    width: 2, 
                    color: Theme.of(context).colorScheme.primary,
                    ),
                label: Center(
                  child: Text(
                    name,
                    style: TextStyle(
                      color: selected ? Colors.white : Theme.of(context).colorScheme.primary,
                        
                    ),
                    ),
                ),
                shape: RoundedRectangleBorder(
    
                  borderRadius: BorderRadius.circular(75),
                ),
              ),
    );
  }
}