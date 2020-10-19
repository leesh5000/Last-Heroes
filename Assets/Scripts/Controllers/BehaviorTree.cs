using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviorTree : MonoBehaviour
{
    // Behaviour Tree
    // 트리는 왼쪽에서 오른쪽으로 순회

    // 노드의 3가지 상태
    // Success : 부모 노드에게 성공을 알려줌
    // Failure : 부모 노드에게 실패를 알려줌
    // Running : 진행 중인 상태

    // 노드의 3가지 타입
    // Composite
    // - 하나 이상의 자식 노드를 가질 수 있는 노드로 Sequence, Selector 가 있음
    // - Sequence는 자식 노드를 순서대로 실행하는 노드 (깊이우선탐색), 자식 노드 중 하나라도 Failure면 실패, 모든 자식이 통과하면 성공
    // - Selector는 자식 노드 중 Success가 반환되면 즉시 성공, 모든 자식이 실패하면 실패
    // Decorator
    // - 하나의 자식 노드만을 갖는 노드, 노드의 결과를 반복하거나 반전하는 역할
    // Leaf
    // - 최하위 노드로 실제 게임에 필요한 로직이 담겨있다.

    class Tree<T>
    {
        
    }

    class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();
    }

    TreeNode<string> MakeTree()
    {
        TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
        {
            {
                TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                node.Children.Add(new TreeNode<string>() { Data = "전투" });
                node.Children.Add(new TreeNode<string>() { Data = "경제" });
                node.Children.Add(new TreeNode<string>() { Data = "스토리" });

                root.Children.Add(node);
            }

            {
                TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
                node.Children.Add(new TreeNode<string>() { Data = "서버" });
                node.Children.Add(new TreeNode<string>() { Data = "클라" });
                node.Children.Add(new TreeNode<string>() { Data = "엔진" });

                root.Children.Add(node);
            }

            {
                TreeNode<string> node = new TreeNode<string>() { Data = "Design" };
                node.Children.Add(new TreeNode<string>() { Data = "Background" });
                node.Children.Add(new TreeNode<string>() { Data = "Character" });

                root.Children.Add(node);
            }
        }

        return root;
    }

    void PrintTree(TreeNode<string> root)
    {
        System.Console.WriteLine(root.Data);

        foreach (TreeNode<string> child in root.Children)
        {
            PrintTree(child);
        }
    }

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
